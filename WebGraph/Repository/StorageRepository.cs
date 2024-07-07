using AutoMapper;
using WebGraph.Abstraction;
using WebGraph.Data;
using WebGraph.Dto;
using WebGraph.Models;

namespace WebGraph.Repository
{
    public class StorageRepository : IStorageRepository
    {
        private readonly AppContex _appContext;
        private readonly IMapper _mapper;

        public StorageRepository(AppContex appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }

        public IEnumerable<StorageDto> GetAllStorages()
        {
            return _appContext.Storages.Select(s => _mapper.Map<StorageDto>(s)).ToList();
        }

        public int AddStorage(StorageDto storageDto)
        {
            var entity = _mapper.Map<Storage>(storageDto);
            _appContext.Storages.Add(entity);
            _appContext.SaveChanges();
            return entity.Id;
        }

        public void UpdateStorageCount(int storageId, int count)
        {
            var storage = _appContext.Storages.Find(storageId);
            if (storage != null)
            {
                storage.Count = count;
                _appContext.SaveChanges();
            }
        }

        public void DeleteStorage(int id)
        {
            var storage = _appContext.Storages.Find(id);
            if (storage != null)
            {
                _appContext.Storages.Remove(storage);
                _appContext.SaveChanges();
            }
        }
    }
}
