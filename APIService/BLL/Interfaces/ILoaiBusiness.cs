using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface ILoaiBusiness
    {
        List<LoaiModel> GetLoais();
        public List<LoaiCon1Model> GetLoai1();
        List<LoaiCon1Model> GetLoai1theoloai(int id);
        public List<LoaiCon2Model> GetLoai2();
        public List<LoaiCon2Model> GetLoai2theoloai(string id);
        public List<LoaiModel> getAllWithChildren();
    }
}
