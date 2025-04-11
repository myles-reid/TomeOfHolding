using AutoMapper;
using TomeOfHolding.Models.DTO;
namespace TomeOfHolding.Models {
	public class MapperProfile : Profile {
		public MapperProfile() {
			CreateMap<CharacterSheet, CharSheetCreateDTO>().ReverseMap();
			CreateMap<Player, PlayerCreateDTO>().ReverseMap();
			CreateMap<Character, CharacterCreateDTO>().ReverseMap();
		}
	}
}
