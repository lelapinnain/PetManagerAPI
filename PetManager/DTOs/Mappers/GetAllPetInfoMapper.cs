using PetManager.DTOs.OutputDTOs;
using PetManager.Models;

namespace PetManager.DTOs.Mappers
{
    public class GetUserInfoMapper : AbstractMapper<GetUserInfoOutputDTO>
    {
        private GetUserInfoOutputDTO getUserInfoOutputDTO;
        private User user;
        private string token;

        public GetUserInfoMapper(User _user, string _token)
        {
            user = _user;
            token = _token;

            getUserInfoOutputDTO = new GetUserInfoOutputDTO();
        }

        public override GetUserInfoOutputDTO GetMappedDTO()
        {
            getUserInfoOutputDTO.FirstName = user.FirstName;
            getUserInfoOutputDTO.LastName = user.LastName;
            getUserInfoOutputDTO.Email = user.Email;
            getUserInfoOutputDTO.token = token;

            return getUserInfoOutputDTO;
        }
    }
}
