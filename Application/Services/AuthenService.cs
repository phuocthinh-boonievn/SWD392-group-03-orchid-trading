using Application.Common.Dto.Authen;
using Application.Common.Dto.Exception;
using Application.Common.Dto.Page;
using Application.Common.Dto.User;
using Application.Interfaces.Users;
using AutoMapper;
using Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class AuthenService : IUserService
    {
        private readonly IUserRepositoy userRepositoy;
        private readonly IMapper mapper;
        public AuthenService
            (IUserRepositoy userRepositoy, IMapper mapper)
        {
            this.userRepositoy = userRepositoy;
            this.mapper = mapper;
        }


        public async Task Delete(int id)
        {
            try
            {
                var user = await userRepositoy.FindIDToResult(id);

                if (user == null)
                {
                    throw new MyException("Kiểm tra lại UserID.", 404);
                }

                await userRepositoy.Delete(user);
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }

        public async Task Edit(int id)
        {
            try
            {
                var user = await userRepositoy.FindIDToResult(id);

                if (user == null)
                {
                    throw new MyException("Kiểm tra lại UserID.", 404);
                }
                else
                {
                    if (user.Status)
                    {
                        user.Status = false;
                        await userRepositoy.Update(user);
                    }
                    else
                    {
                        user.Status = true;
                        await userRepositoy.Update(user);
                    }
                }
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }

        public async Task<List<ViewInformationUserDTO>> GetAll(PageDto page)
        {
            try
            {
                var user = mapper.Map<List<ViewInformationUserDTO>>
                    (await userRepositoy.GetAll(page));
                return user;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }


        public async Task<Token> Login(LoginDto loginDto)
        {
            try
            {
                var user = await userRepositoy.GetUserByEmail(loginDto.Email);
                var token = new Token();
                if (user == null)
                {
                    throw new MyException("Tên đăng nhập không đúng hoặc không tồn tại.", 404);
                }
                else
                {
                    if (!VerifyPasswordHash
                        (loginDto.Password, user.PasswordHash, user.PasswordSalt))
                    {
                        throw new MyException("Mật khẩu của bạn không đúng.", 404);
                    }
                    else
                    {
                        return mapper.Map<Token>(user);
                    }
                }
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }

        public async Task Register(RegisterDto registerDto)
        {
            try
            {
                if (await userRepositoy.GetUserByEmail
                    (registerDto.Email) is not null)
                {
                    throw new MyException("Email đã tồn tại.", 404);
                }
                else if (!registerDto.PasswordConfirm
                    .Equals(registerDto.PasswordConfirm))
                {
                    throw new MyException("Mật khẩu không khớp.", 404);
                }

                CreatePasswordHash(registerDto.Password, out byte[] password_hash, out byte[] password_salt);

                var user = mapper.Map<RegisterDto, User>(registerDto,
                opt => opt.AfterMap((src, des) =>
                {
                    des.PasswordHash = password_hash;
                    des.PasswordSalt = password_salt;
                }));

                await userRepositoy.Create(user);
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }

        public async Task<List<ViewInformationUserDTO>> Search(string search)
        {
            try
            {
                //var user = await userRepositoy.Search(search);
                var user = mapper.Map<List<ViewInformationUserDTO>>(await userRepositoy.Search(search));
                return user;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
