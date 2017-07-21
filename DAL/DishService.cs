using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Models;

namespace DAL
{
    /// <summary>
    /// 菜品数据访问类
    /// </summary>
    public class DishService
    {
        /// <summary>
        /// 获取所有的菜品分类
        /// </summary>
        /// <returns></returns>
        public List<DishCategory> GetAllCategory()
        {
            string sql = "select CategoryId, CategoryName from DishCategory";
            List<DishCategory> list = new List<DishCategory>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new DishCategory()
                    {
                        CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                        CategoryName = objReader["CategoryName"].ToString()
                    }
                );
            }

            //关闭reader
            objReader.Close();
            return list;

        }
        /// <summary>
        /// 添加菜品，获取添加后菜品的ID，用作图片的编号
        /// </summary>
        /// <param name="objDish"></param>
        /// <returns>菜品的ID</returns>
        public int AddDish(Dish objDish)
        {
            string sql = "insert into Dishes(DishName, UnitPrice, CategoryId) ";
            sql += " values(@DishName, @UnitPrice, @CategoryId); select @@identity";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DishName", objDish.DishName),
                new SqlParameter("@UnitPrice", objDish.UnitPrice),
                new SqlParameter("@CategoryId", objDish.CategoryId)
            };

            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql, param));
            return result;
        }
    }
}
