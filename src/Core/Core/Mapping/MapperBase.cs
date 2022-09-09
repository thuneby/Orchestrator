using AutoMapper;

namespace Core.Mapping
{
    public abstract class MapperBase<T1, T2>
    {

        protected IMapper Mapper;

        protected MapperBase()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());
            Mapper = config.CreateMapper();
        }

        protected MapperBase(IConfigurationProvider config)
        {
            Mapper = config.CreateMapper();
        }

        public static T2 GetRecord(T1 record)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());
            var mapper = config.CreateMapper();
            var result = mapper.Map<T1, T2>(record);
            return result;
        }

        public static T2 GetRecord(T1 record, MapperConfiguration mapperConfiguration)
        {
            var mapper = mapperConfiguration.CreateMapper();
            var result = mapper.Map<T1, T2>(record);
            return result;
        }

        public static T2 GetRecord(T1 record, IMapper mapper)
        {
            var result = mapper.Map<T1, T2>(record);
            return result;
        }

        public T2 Map(T1 record)
        {
            var result = Mapper.Map<T1, T2>(record);
            return result;
        }
    }
}
