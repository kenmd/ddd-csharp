using AutoMapper;

using DddInPractice.Logic;


namespace DddInPractice.Repository
{
    /// <summay>
    /// auto mapping profile between SnackMachine.MoneyInside and SnackMachineDto
    /// </summay>
    public class SnackMachineProfile : Profile
    {
        public SnackMachineProfile()
        {
            // ReplaceMemberName("Id", "SnackMachineID");
            CreateMap<SnackMachine, SnackMachineDto>()
                .ForMember(dest => dest.SnackMachineID, opt => opt.MapFrom(src => src.Id))
                .IncludeMembers(e => e.MoneyInside)
                .ReverseMap();

            CreateMap<Money, SnackMachineDto>()
                .ForMember(dest => dest.SnackMachineID, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
