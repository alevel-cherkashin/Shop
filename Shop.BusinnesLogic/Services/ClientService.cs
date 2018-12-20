using Shop.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Data;
using Shop.Data.DTOs;
using Shop.Data.Extensions;

namespace Shop.BusinnesLogic.Services
{
    public interface IClientService
    {
        int Add(ClientDto clientDto);

        void Update(ClientDto clientDto);

        void Delete(int id);

        bool Validate(string name);

        List<ClientDto> Search(string name);

        ClientDto GetDetails(int id);

        List<ClientDto> Get();

        List<ClientDto> GetLimited(int number);
    }

    public class ClientService: IClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public bool Validate(string name)
        {
            return _unitOfWork.EFClientRepository.Get().Any(c => c.Name.ToLower() == name.ToLower());
        }

        public int Add(ClientDto clientDto)
        {
            var client = clientDto.ToSqlModel();
            
            _unitOfWork.EFClientRepository.Add(client);

            _unitOfWork.Save();
            return client.Id;
        }

        public void Delete(int id)
        {
            _unitOfWork.EFClientRepository.Delete(id);

            _unitOfWork.Save();
        }

        public List<ClientDto> Get()
        {
            return _unitOfWork.EFClientRepository.Get().Select(x => x.ToDto()).ToList();
        }

        public ClientDto GetDetails(int id)
        {
            return _unitOfWork.EFClientRepository.GetDeteils(id).ToDto();
        }

        public void Update(ClientDto clientDto)
        {
            var client = clientDto.ToSqlModel();
            _unitOfWork.EFClientRepository.Update(client);

            _unitOfWork.Save();
        }

        public List<ClientDto> GetLimited(int number)
        {
            var list = _unitOfWork.EFClientRepository.Get();

            if (number > list.Count||number <=0)
            {
                throw new ArgumentException("Number");
            }

            var clients = _unitOfWork.EFClientRepository.Get().Select(c => c.ToDto()).Take(number);
           
            return clients.ToList(); 
        }

        public List<ClientDto> Search(string name)
        {
            var list = _unitOfWork.EFClientRepository.Get();

            return list.Where(x => x.Name.Contains(name)).Select(x=>x.ToDto()).ToList();
        }
    }
}
