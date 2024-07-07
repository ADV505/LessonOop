using WebGraph.Dto;

namespace WebGraph.Abstraction
{
    public interface IStorageRepository
    {
        IEnumerable<StorageDto> GetAllStorages();
        int AddStorage(StorageDto storageDto);
        void UpdateStorageCount(int storageId, int count);
        void DeleteStorage(int id);
    }
}
