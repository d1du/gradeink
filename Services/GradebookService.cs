using Derek.Web.Domain;
using Derek.Web.Models.GradebookEntries;
using Sabio.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Derek.Web.Services
{
    public class GradebookService : BaseService
    {
        public static int AddGradebookEntry(GradebookEntryAddRequest model)
        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.AddGradebookEntry"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   if (model != null)
                   {
                       //@UserId should be obtained via a get
                       paramCollection.AddWithValue("@AssignmentId", model.AssignmentId);
                       paramCollection.AddWithValue("@PointsEarned", model.PointsEarned);
                       paramCollection.AddWithValue("@InstructorComments", model.InstructorComments);
                       paramCollection.AddWithValue("@UserId", model.UserId);
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

        public static void UpdateGradebookEntryById(GradebookEntryUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.UpdateGradebookEntryById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", model.Id);
                   paramCollection.AddWithValue("@AssignmentId", model.AssignmentId);
                   paramCollection.AddWithValue("@PointsEarned", model.PointsEarned);
                   paramCollection.AddWithValue("@InstructorComments", model.InstructorComments);

               }, returnParameters: delegate (SqlParameterCollection param)
               { }
               );
        }

        public static void DeleteGradebookEntryById(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.DeleteGradebookEntryById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", id);
               }, returnParameters: delegate (SqlParameterCollection param)
               {
               }
               );
        }

        public static List<BaseGradebookEntry> GetUserGrades(ShortenedUserId model)
        {
            List<BaseGradebookEntry> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.GetUserGradesByUserId"
                    , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                           {
                               paramCollection.AddWithValue("@UserId", model.UserId);
                           }
                           , map: delegate (IDataReader reader, short set)
                           {
                               BaseGradebookEntry p = new BaseGradebookEntry();
                               int startingIndex = 0; //startingOrdinal

                               p.GradebookEntryId = reader.GetSafeInt32(startingIndex++);
                               p.AssignmentId = reader.GetSafeInt32(startingIndex++);
                               p.AssignmentName = reader.GetSafeString(startingIndex++);
                               p.AssignmentTypeId = reader.GetSafeInt32(startingIndex++);
                               p.PointsEarned = reader.GetSafeInt32(startingIndex++);
                               p.TotalPoints = reader.GetSafeInt32(startingIndex++);
                               p.DateAdded = reader.GetSafeDateTime(startingIndex++);
                               p.InstructorComments = reader.GetSafeString(startingIndex++);

                               if (list == null)
                               {
                                   list = new List<BaseGradebookEntry>();
                               }

                               list.Add(p);

                           }
                           );

            return list;
        }

        public static GradebookEntry SelectGradebookEntryById(int id)
        {
            GradebookEntry p = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.SelectGradebookEntryById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", id);
               }, map: delegate (IDataReader reader, short set)
               {
                   p = new GradebookEntry();
                   int startingIndex = 0;

                   p.UserId = reader.GetSafeString(startingIndex++);
                   p.AssignmentId = reader.GetSafeInt32(startingIndex++);
                   p.AssignmentName = reader.GetSafeString(startingIndex++);
                   p.AssignmentTypeId = reader.GetSafeInt32(startingIndex++);
                   p.PointsEarned = reader.GetSafeInt32(startingIndex++);
                   p.TotalPoints = reader.GetSafeInt32(startingIndex++);
                   p.DateAdded = reader.GetSafeDateTime(startingIndex++);
                   p.InstructorComments = reader.GetSafeString(startingIndex++);
               });

            return p;
        }

        public static UserGradePercentage GetUserPercentage(string userId, string storeProc)
        {
            UserGradePercentage p = null;

            DataProvider.ExecuteCmd(GetConnection, storeProc
                    , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                    {
                        paramCollection.AddWithValue("@UserId", userId);
                    }
                           , map: delegate (IDataReader reader, short set)
                           {
                               p = new UserGradePercentage();
                               int startingIndex = 0; //startingOrdinal

                               p.PointsEarned = reader.GetSafeInt32(startingIndex++);
                               p.TotalPoints = reader.GetSafeInt32(startingIndex++);
                               p.Percentage = reader.GetSafeDouble(startingIndex++);

                           }
                           );

            return p;
        }

    }
}