using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diginovasi.BusinessObjects.Masters;
using Diginovasi.BusinessObjects.Sales;
using Diginovasi.DataTransferObjects.Masters;
using Diginovasi.DataTransferObjects.Sales;
namespace Diginovasi.Api.Configurations
{
    public class AutomapperConfiguration:Profile
    {
        public AutomapperConfiguration()
        {
            SatuanMapping();
            MaterialMapping();
            CustomerMapping();
            SalesOrderItemMapping();
            SalesOrderMapping();
        }
        private void SatuanMapping()
        {
            CreateMap<Satuan, SatuanDto>().ReverseMap();
        }
        private void MaterialMapping()
        {
            CreateMap<Material, MaterialDto>().ForMember(dest => dest.KodeSatuan, 
                src => src.MapFrom(c => c.Satuan == null ? string.Empty:c.Satuan.Kode));
            CreateMap<MaterialDto, Material>();

        }
        private void CustomerMapping()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
        private void SalesOrderItemMapping()
        {
            CreateMap<SalesOrderItem, SalesOrderItemDto>()
                .ForMember(dest => dest.DeskripsiMaterial, src => src.MapFrom(c => c.Material == null ? string.Empty : c.Material.Deskripsi))
                .ForMember(dest => dest.KodeMaterial, src => src.MapFrom(c => c.KodeMaterial == null ? string.Empty : c.KodeMaterial))
                .ForMember(dest => dest.KodeSatuan, src => src.MapFrom(c => c.Material == null ? string.Empty : (c.Material.Satuan == null ? string.Empty : c.Material.Satuan.Kode)))
                .ForMember(dest => dest.Harga, src => src.MapFrom(c => c.Material == null ? 0 : c.Material.Harga))
                .ForMember(nameof(SalesOrderItemDto.SubTotal), (entity) =>
                {
                    entity.MapFrom(src => src.Jumlah * (src.Material != null ? src.Material.Harga : 1));
                });
            CreateMap<SalesOrderItemDto, SalesOrderItem>();

        }
        private void SalesOrderMapping()
        {
            CreateMap<SalesOrder, SalesOrderDto>()
                .ForMember(dest => dest.NoCustomer, src => src.MapFrom(c => c.Customer != null ? c.Customer.NoCustomer : string.Empty))
                .ForMember(dest => dest.NamaCustomer, src => src.MapFrom(c => c.Customer != null ? c.Customer.Nama : string.Empty))
                .ForMember(dest => dest.Total, src => src.MapFrom(c => c.SalesOrderItems.Sum(i => i.Jumlah * (i.Material!=null ? i.Material.Harga : 1))));
            CreateMap<SalesOrderDto, SalesOrder>();
        }
    }
}
