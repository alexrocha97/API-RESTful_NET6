using API.Entities;
using API.Entities.ViewModels;
using API.Infra;
using AutoMapper;

namespace API.Services
{
    public class UserService
    {
        private readonly IMongoRepository<User> _user;
        private readonly IMapper _mapper;
        public UserService(IMongoRepository<User> user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public bool ValidateUser(LoginViewModel loginUser)
        {
            var result = GetAll()
                .Where(x => x.Email == loginUser.Username 
                        && x.Password == loginUser.Password).Any();
            return result;
        }

        public List<UserViewModel> GetAll()
        {
            return _mapper.Map<List<UserViewModel>>(_user.Getall());
        }

        public UserViewModel Get(string id)
        {
            return _mapper.Map<UserViewModel>(_user.Get(id));
        }

        public UserViewModel Create(UserViewModel usuario)
        {
            var entity = new User(usuario.Email,usuario.Password, usuario.Status);
            _user.Create(entity);

            return Get(entity.Id);
        }

        public void Update(string id, User userIn)
        {
            _user.Update(id, userIn);
        }

        public void Remove(string id) => _user.Remove(id);
    }
}
