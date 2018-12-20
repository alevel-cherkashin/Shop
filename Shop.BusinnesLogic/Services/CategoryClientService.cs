using Shop.Data;
using Shop.Data.DTOs;
using Shop.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BusinnesLogic.Services
{
    public interface ICategoryClientService
    {
        int Add(CategoryClientDto categoryClientDto);

        void Update(CategoryClientDto categoryClientDto);

        void Delete(int id);

        CategoryClientDto GetDetails(int id);

        List<CategoryClientDto> Get();
    }

    public class CategoryClientService : ICategoryClientService
    {
        private UnitOfWork _unitOfWork;

        public CategoryClientService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(CategoryClientDto categoryClientDto)
        {
            _unitOfWork.EFCategoryRepository.Add(categoryClientDto.ToSqlModel());

            _unitOfWork.Save();

            return categoryClientDto.Id;
        }

        public void Delete(int id)
        {
            _unitOfWork.EFCategoryRepository.Delete(id);

            _unitOfWork.Save();
        }

        public List<CategoryClientDto> Get()
        {
            return _unitOfWork.EFCategoryRepository.Get().Select(x=>x.ToDto()).ToList();
        }

        public CategoryClientDto GetDetails(int id)
        {
            return _unitOfWork.EFCategoryRepository.GetDeteils(id).ToDto();
        }

        public void Update(CategoryClientDto categoryClientDto)
        {
            var category = categoryClientDto.ToSqlModel();

            _unitOfWork.EFCategoryRepository.Update(category);

            _unitOfWork.Save();
        }
    }
}
