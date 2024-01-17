using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IKullaniciService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IKullaniciService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<Kullanici> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new Kullanici
            {
                Email = userForRegisterDto.Email,
                Ad = userForRegisterDto.Ad,
                Soyad = userForRegisterDto.Soyad,
                Sifre = passwordHash,
                SifreSalt = passwordSalt,
                Durum = true
            };
            _userService.Add(user);
            return new SuccessDataResult<Kullanici>(user, Messages.UserRegistered);
        }

        public IDataResult<Kullanici> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Kullanici>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Sifre, userToCheck.Sifre, userToCheck.SifreSalt))
            {
                return new ErrorDataResult<Kullanici>(Messages.PasswordError);
            }

            return new SuccessDataResult<Kullanici>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(Kullanici user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
