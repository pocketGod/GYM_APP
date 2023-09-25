using GYM_LOGICS.Builders;
using GYM_MODELS.Client;
using GYM_MODELS.DB;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_LOGICS.Services
{
    public class WorkoutPlanService
    {
        private readonly string _collectionName = "WO_Plans";
        private readonly IMongoCollection<WorkoutPlanDBRecord> _workoutPlans;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly WorkoutPlanBuilder _planBuilder;

        public WorkoutPlanService(
            IMongoDatabase database,
            IHttpContextAccessor httpContextAccessor,
            WorkoutPlanBuilder planBuilder
            )
        {
            _workoutPlans = database.GetCollection<WorkoutPlanDBRecord>(_collectionName);
            _httpContextAccessor = httpContextAccessor;
            _planBuilder = planBuilder;
        }

        public List<WorkoutPlan> GetAllMyPlans()
        {
            string connectedUserId = _httpContextAccessor.HttpContext.Items["UserId"].ToString();
            List<WorkoutPlanDBRecord> dbRecords = _workoutPlans.Find(plan => plan.OwnerUserId == connectedUserId).ToList();
            return dbRecords.Select(_planBuilder.BuildForClient).ToList();
        }


    }
}
