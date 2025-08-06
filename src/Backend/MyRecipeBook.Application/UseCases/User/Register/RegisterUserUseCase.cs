using AutoMapper;
using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {
        // Validar request
        Validate(request);

        // Mapear a request para uma entidade
        var autoMapper = new MapperConfiguration(options => 
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper();

        var user = autoMapper.Map<Domain.Entities.User>(request);

        // Criptografar senha

        // Salvar no banco

        return new ResponseRegisteredUserJson
        {
            Name = request.Name,
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidateException(errorMessages);
        }
    }
}
