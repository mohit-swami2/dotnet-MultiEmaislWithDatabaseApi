using AutoMapper;
using EmailWithDatabaseApi.Dto;
using EmailWithDatabaseApi.Model;

namespace EmailWithDatabaseApi; 

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<PostEmailDto,Emailbody>();
	}
}
