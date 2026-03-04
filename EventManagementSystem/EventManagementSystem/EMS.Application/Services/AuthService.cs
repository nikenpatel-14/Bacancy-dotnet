using AutoMapper;
using EventManagementSystem.EMS.Application.DTOs;
using EventManagementSystem.EMS.Application.Services.Interface;
using EventManagementSystem.EMS.Domain.Entity;
using EventManagementSystem.EMS.Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Identity;

namespace EventManagementSystem.EMS.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository repository;
        private readonly IJwtService JwtService;
        private readonly IMapper mapper;

        public AuthService(IAuthRepository _repository, IJwtService _JwtService,IMapper _mapper)
        {
            JwtService = _JwtService;
            repository = _repository;
            mapper = _mapper;
        }
        public async Task RegisterUser(UserRegistrationDTO userDTO)
        {
            var existingUser = await repository.getUserByEmail(userDTO.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exist");
                
            }
            var user = mapper.Map<User>(userDTO);
            user.Password = new PasswordHasher<User>().HashPassword(user, userDTO.Password);
            await repository.registerUser(user);
            Console.WriteLine("User Registered Succesfully");
            return;
        }
        public async Task<AuthResponseDTO> LoginUser(UserLoginDTO userDTO)
        {
            var user = await repository.getUserByEmail(userDTO.Email);
            if (user == null|| new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, userDTO.Password) == PasswordVerificationResult.Failed)
            {
                throw new Exception("invalid credentials");
            } 
                
            
            var token = JwtService.GenerateToken(user);

            return new AuthResponseDTO 
            {
                Token = token,
                Email = user.Email,
                Role = user.Role.ToString()
            };

        }

    }
}
