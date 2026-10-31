    using Microsoft.AspNetCore.Identity;
    using Website.DTOs;
    using Website.Models;
    using Website.Repository;

    namespace Website.Services
    {
        public class UserServices:IUserServices
        {
            private readonly IUserRepository _repository;

            public UserServices(IUserRepository repository)
            {
                _repository = repository;
            
            }
          public async Task<string> AddUser(RegisterDto add)
            {
                if (add.UserName == "string" || string.IsNullOrWhiteSpace(add.EmailId) || add.EmailId == "user@example.com" || add.Password == "string")
                {
                    return "Enter Correct User Details";
                }
                DateOnly today = DateOnly.FromDateTime(DateTime.Today);

                int age = today.Year - add.DateofBirth.Year;

                if (add.DateofBirth > today.AddYears(-age))
                {
                    age--;
                }
                if (age < 18)
                {
                    return "User Must Be At Least 18 Years Old";
                }
            if (add.DateofBirth > today)
            {
                return "Date of Birth Cannot Be in the Future";
            }
            add.EmailId = add.EmailId.Trim().ToLowerInvariant();
                var email = await _repository.GetUserByEmail(add.EmailId);
                if (email != null)
                {
                    return "EmialId Already Register";
                }
                if (add.Password != add.Confirm_Password)
                {
                    return "Password and Confirm_Password are Not Same";
                }
                var Dub = new User
                {
                    UserName = add.UserName,
                    EmailId = add.EmailId,
                    Password = add.Password,
                    DateofBirth = add.DateofBirth
                };

                await _repository.AddUser(Dub);
                return "User Register Successfully";
            }
           public async Task<List<RegisterDto>> GetAllUsers()
            {
                var users = await _repository.GetAllUsers();

                return users.Select(user => new RegisterDto
                {
                    UserName = user.UserName,
                    EmailId = user.EmailId,
                    Password = user.Password,
                    DateofBirth = user.DateofBirth}).ToList();
            }
            public async Task<RegisterDto?> GetbyId(int id)
            {
                var add = await _repository.GetUserbyId(id);
                if (add == null)
                {
                    return null;
                }
                return new RegisterDto
                {
                    UserName = add.UserName,
                    EmailId = add.EmailId,
                    DateofBirth = add.DateofBirth
                }; 
            }
            public async Task<string> GetUserbyEmail(LoginDto login)
            {
                var email = await _repository.GetUserByEmail(login.EmailId);
                if (email == null)
                {
                    return "Email Id Not Registered";
                }
                if (login.EmailId==email.EmailId && email.Password != login.Password)
                {
                    return "EmailId And Password is Not Right";
                }

                return "Login Successfully";
            }
        }
    }
