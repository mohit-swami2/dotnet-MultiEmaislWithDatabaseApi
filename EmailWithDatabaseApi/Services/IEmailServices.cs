using EmailWithDatabaseApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EmailWithDatabaseApi.Services
{
    public interface IEmailServices
    {
        string GetObject(EmailDto request);
        void Post(PostEmailDto newemail);

        List<string> GetAll();
    }
}
