using AutoMapper;
using System.Collections.Generic;

namespace Abp.Mapping
{
    /// <summary>
    /// TODO: It's not so good to be depended to a mapping library!
    /// </summary>
    public static class AutoMapExtensions
    {
        private static MapperConfiguration config;
        public static MapperConfiguration Config
        {
            get
            {
                if (config == null)
                    config = new AutoMapper.MapperConfiguration(c => { });

                return config;
            }
        }

        public static IList<TD> MapIList<TS, TD>(this IList<TS> items)
        {
            IList<TD> mapped = items.MapTo<IList<TD>>();
            return mapped;
        }

        public static void Configure(System.Action<IMapperConfiguration> configure)
        {
            configure(Config);
        }


        public static T MapTo<T>(this object obj)
        {
            if (obj == null)
            {
                return default(T);
            }

            return config.CreateMapper().Map<T>(obj);
        }
    }
}