using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
using System.Linq;

namespace BLL
{
    public partial class LoaiBusiness : ILoaiBusiness
    {
        private ILoaiRepository _res;
        public LoaiBusiness(ILoaiRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
      
        }

        public List<LoaiModel> GetLoais()
        {
            var loais = _res.GetDataAll();
           
            return loais;
        }
        public List<LoaiCon1Model> GetLoai1()
        {
            var loais = _res.GetLoai1();

            return loais;
        }
        public List<LoaiCon1Model> GetLoai1theoloai(int id)
        {
            var loais = _res.getloai1byloai(id);

            return loais;
        }
        public List<LoaiCon2Model> GetLoai2()
        {
            var loais = _res.GetLoai2();

            return loais;
        }
        public List<LoaiCon2Model> GetLoai2theoloai(string id)
        {
            var loais = _res.getbyloai1(id);

            return loais;
        }
        public List<LoaiModel> getAllWithChildren()
        {
            var loais = _res.GetDataAll();
            var loai1 = _res.GetLoai1();
            var loai2 = _res.GetLoai2();
            foreach (var item in loais)
            {
               item.children=loai1.Where(s=>s.MaLoaiCha==item.MaLoai).ToList();
            }
            foreach (var item in loai1)
            {
                item.children = loai2.Where(s => s.MaLoaiCha == item.MaLoai).ToList();
            }
            return loais;
        }
     

    }
}
