using Shouldly;
using System.Linq;
using Backend.Application.Business.Business.Users.CreateUser;
using Xunit;

namespace Backend.API.FunctionalTests.ValidatorTests.UserValidatorTests
{
    public class CreateUserCommandValidatorTests
    {
        private CreateUserRequest Model { get; set; }
        private readonly CreateUserRequestValidator _validator;

        public CreateUserCommandValidatorTests()
        {
            Model = new CreateUserRequest()
            {
                Username = "Test",
                FirstName = "Marko",
                LastName = "Urh",
                Email = "urh.marko@gmail.com",
                Password = "12345",
                ConfirmPassword = "12345"
            };

            _validator = new CreateUserRequestValidator();
        }

        #region EMAIL

        [Fact]
        public void Email_Success()
        {
            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void Email_WrongEmail_Fails()
        {
            Model.Email = "urh.marko";

            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(false);
            result.Errors.Any(x => x.PropertyName == "Email").ShouldBe(true);
            result.Errors.Count.ShouldBe(1);
        }


        [Fact]
        public void Email_NoEmail_Fails()
        {
            Model.Email = "";

            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(false);
            result.Errors.Any(x => x.PropertyName == "Email").ShouldBe(true);
            result.Errors.Count.ShouldBe(2);
        }

        #endregion

        #region USERNAME

        [Fact]
        public void Username_Success()
        {
            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void Username_MaxLength_Fails()
        {
            Model.Username = "1234567890123456";

            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(false);
            result.Errors.Any(x => x.PropertyName == "Username").ShouldBe(true);
            result.Errors.Count.ShouldBe(1);
        }

        [Fact]
        public void Username_Empty_Fails()
        {
            Model.Username = "";

            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(false);
            result.Errors.Any(x => x.PropertyName == "Username").ShouldBe(true);
            result.Errors.Count.ShouldBe(1);
        }

        #endregion

        #region FIRSTNAME

        [Fact]
        public void FirstName_Success()
        {
            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void FirstName_MaxLength_Fails()
        {
            Model.FirstName = "1234567890123456";

            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(false);
            result.Errors.Any(x => x.PropertyName == "FirstName").ShouldBe(true);
            result.Errors.Count.ShouldBe(1);
        }


        [Fact]
        public void FirstName_Empty_Success()
        {
            Model.FirstName = "";

            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(true);
        }


        #endregion

        #region LASTNAME

        [Fact]
        public void LastName_Success()
        {
            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void LastName_MaxLength_Fails()
        {
            Model.LastName = "1234567890123456";

            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(false);
            result.Errors.Any(x => x.PropertyName == "LastName").ShouldBe(true);
            result.Errors.Count.ShouldBe(1);
        }


        [Fact]
        public void LastName_Empty_Success()
        {
            Model.LastName = "";

            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(true);
        }


        #endregion

        #region PASSWORD

        [Fact]
        public void Password_Success()
        {
            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void Password_SamePasswordWrongLength_Fails()
        {
            Model.Password = "1234";
            Model.Password = "1234";

            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(false);
            result.Errors.Any(x => x.PropertyName == "Password").ShouldBe(true);
            result.Errors.Count.ShouldBe(1);
        }


        [Fact]
        public void Password_WrongConfirmationPassword_Fails()
        {
            Model.Password = "12345";
            Model.Password = "123456";

            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(false);
            result.Errors.Any(x => x.PropertyName == "Password").ShouldBe(true);
            result.Errors.Count.ShouldBe(1);
        }

        [Fact]
        public void Password_Empty_Fails()
        {
            Model.Password = "";
            Model.Password = "";

            var result = _validator.Validate(Model);
            result.IsValid.ShouldBe(false);
            result.Errors.Any(x => x.PropertyName == "Password").ShouldBe(true);
            result.Errors.Count.ShouldBe(2);
        }

        #endregion
    }
}
