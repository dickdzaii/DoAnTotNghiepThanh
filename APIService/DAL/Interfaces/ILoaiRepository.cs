using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ILoaiRepository
    {
        List<LoaiModel> GetDataAll();
        public List<LoaiCon1Model> getloai1byloai(int id);
        public List<LoaiCon1Model> GetLoai1();
        public List<LoaiCon2Model> GetLoai2();
        public List<LoaiCon2Model> getbyloai1(string id);
    }
}
