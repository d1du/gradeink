using Derek.Web.Domain;
using Derek.Web.Models.Assignments;
using Sabio.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Derek.Web.Services
{
    public class AssignmentService : BaseService
    {
        public static int AddAssignment(AssignmentAddRequest model)
        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.AddAssignment"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   if (model != null)
                   {
                       //@UserId should be obtained via a get
                       paramCollection.AddWithValue("@AssignmentName", model.AssignmentName);
                       paramCollection.AddWithValue("@AssignmentTypeId", model.AssignmentTypeId);
                       paramCollection.AddWithValue("@TotalPoints", model.TotalPoints);
                       paramCollection.AddWithValue("@Period", model.Period);
                   }

                   SqlParameter p = new SqlParameter("@Id", SqlDbType.Int);
                   p.Direction = ParameterDirection.Output;

                   paramCollection.Add(p);
               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out id);
               }
               );

            return id;

        }

        public static void UpdateAssignment(AssignmentUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.UpdateAssignment"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", model.Id);
                   paramCollection.AddWithValue("@AssignmentName", model.AssignmentName);
                   paramCollection.AddWithValue("@AssignmentTypeId", model.AssignmentTypeId);
                   paramCollection.AddWithValue("@TotalPoints", model.TotalPoints);
                   paramCollection.AddWithValue("@Period", model.Period);

               }, returnParameters: delegate (SqlParameterCollection param)
               { }
               );
        }

        public static void DeleteAssignmentById(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.DeleteAssignmentById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", id);
               }, returnParameters: delegate (SqlParameterCollection param)
               {
               }
               );
        }

        public static List<Assignment> GetAssignmentsByPeriod(int period)
        {
            List<Assignment> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.GetAssignmentsByPeriod"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Period", period);
               }
               , map: delegate (IDataReader reader, short set)
               {
                   Assignment p = new Assignment();
                   int startingIndex = 0;

                   p.AssignmentId = reader.GetSafeInt32(startingIndex++);
                   p.AssignmentName = reader.GetSafeString(startingIndex++);
                   p.AssignmentTypeId = reader.GetSafeInt32(startingIndex++);
                   p.TotalPoints = reader.GetSafeInt32(startingIndex++);
                   p.Period = reader.GetSafeInt32(startingIndex++);
                   p.DateAdded = reader.GetSafeDateTime(startingIndex++);

                   if (list == null)
                   {
                       list = new List<Assignment>();
                   }

                   list.Add(p);
               }
               );

            return list;
        }

        public static Assignment SelectAssignmentById(int id)
        {
            Assignment p = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.SelectAssignmentById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", id);
               }, map: delegate (IDataReader reader, short set)
               {
                   p = new Assignment();
                   int startingIndex = 0;

                   p.AssignmentId = reader.GetSafeInt32(startingIndex++);
                   p.AssignmentName = reader.GetSafeString(startingIndex++);
                   p.AssignmentTypeId = reader.GetSafeInt32(startingIndex++);
                   p.TotalPoints = reader.GetSafeInt32(startingIndex++);
                   p.Period = reader.GetSafeInt32(startingIndex++);
                   p.DateAdded = reader.GetSafeDateTime(startingIndex++);

               });

            return p;
        }

        public static List<Assignment> GetAllAssignments()
        {
            List<Assignment> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.SelectAllAssignments"
               , inputParamMapper: null
               , map: delegate (IDataReader reader, short set)
               {
                   Assignment p = new Assignment();
                   int startingIndex = 0;

                   p.AssignmentId = reader.GetSafeInt32(startingIndex++);
                   p.AssignmentName = reader.GetSafeString(startingIndex++);
                   p.AssignmentTypeId = reader.GetSafeInt32(startingIndex++);
                   p.TotalPoints = reader.GetSafeInt32(startingIndex++);
                   p.Period = reader.GetSafeInt32(startingIndex++);
                   p.DateAdded = reader.GetSafeDateTime(startingIndex++);

                   if (list == null)
                   {
                       list = new List<Assignment>();
                   }

                   list.Add(p);
               }
               );

            return list;
        }

    }
}