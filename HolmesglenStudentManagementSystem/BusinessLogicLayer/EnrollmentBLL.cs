﻿using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class EnrollmentBLL
    {
        AppDAL appDAL;
        public EnrollmentBLL()
        {
            appDAL = new AppDAL();
        }
        public List<Enrollment> GetAll()
        {
            return appDAL.EnrollmentDALInstance.ReadAll();
        }

        public Enrollment GetOne(string id)
        {
            return appDAL.EnrollmentDALInstance.Read(id);
        }

        public bool Create(Enrollment enrollment)
        {
            if (GetOne(enrollment.EnrollmentID) != null)
            {
                // if student id exists, return false
                return false;
            }
            else
            {
                // if student id does not exist, create it
                appDAL.EnrollmentDALInstance.Create(enrollment);
            }

            return true;
        }

        public bool Update(Enrollment enrollment)
        {
            if (GetOne(enrollment.EnrollmentID) == null)
            {
                // if student id does not exist, return false
                return false;
            }
            else
            {
                // if student id exists, update it
                appDAL.EnrollmentDALInstance.Update(enrollment);
            }

            return true;
        }

        public bool Delete(string id)
        {
            if (GetOne(id) == null)
            {
                // if student id does not exist, return false
                return false;
            }
            else
            {
                // if student id exists, delete it
                appDAL.EnrollmentDALInstance.Delete(id);
            }

            return true;
        }
    }
}
