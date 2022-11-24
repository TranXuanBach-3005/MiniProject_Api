using AutoMapper;
using BachTX9_MiniProject_API.Data;
using BachTX9_MiniProject_API.DTOs.UserDtos;
using BachTX9_MiniProject_API.JwtConfiguration;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Repository
{
    public class AccountRepository : GenericRepository<User>, IAccountRepository
    {
        private readonly JwtConfig _jwtConfig;
        private readonly IMapper _mapper;
        public AccountRepository(DataDbContext context, IOptionsMonitor<JwtConfig> optionsMonitor, IMapper mapper) : base(context)
        {
            _jwtConfig = optionsMonitor.CurrentValue;
            _mapper = mapper;
        }
        public User AddUserAnync(UserRegisterDto userRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = _mapper.Map<User>(userRegisterDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _context.users.Add(user);
            return user;
        }

        public async Task<User> Authenticate(UserLoginDto userLoginDto)
        {
            var result = await _context.users.FirstOrDefaultAsync(n => n.UserName == userLoginDto.UserName);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<string> Login(UserLoginDto userLoginDto)
        {
            var user = await Authenticate(userLoginDto);
            if (user != null)
            {
                var token = GenereateJwtTonken(user);
                return token;
            }
            return null;
        }
        public bool lockAccount(int id)
        {
            var acc = GetById(id);
            if (acc == null) return false;
            acc.Status = true;
            Update(acc);
            return true;
        }
        public string GenereateJwtTonken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.UserId.ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString() )
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash,
                                                out byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty");
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<User> GetByUserName(string userName, string password)
        {
            var result = await _context.users.FirstOrDefaultAsync(n => n.UserName == userName && n.Password == password);
            return result;
        }
    }
}
