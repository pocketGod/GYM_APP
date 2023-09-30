using GYM_DB.Repositories;
using GYM_LOGICS.Builders;
using GYM_MODELS.Client;
using GYM_MODELS.DB;
using Microsoft.AspNetCore.Http;

namespace GYM_LOGICS.Services
{
    public class WorkoutPlanService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly WorkoutPlanBuilder _planBuilder;
        private readonly IWorkoutPlanRepository _workoutPlanRepository;

        public WorkoutPlanService(
            IHttpContextAccessor httpContextAccessor,
            WorkoutPlanBuilder planBuilder,
            IWorkoutPlanRepository workoutPlanRepository
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _planBuilder = planBuilder;
            _workoutPlanRepository = workoutPlanRepository;
        }

        public List<WorkoutPlan> GetAllMyPlans()
        {
            string connectedUserId = _httpContextAccessor.HttpContext.Items["UserId"].ToString();
            List<WorkoutPlanDBRecord> dbRecords = _workoutPlanRepository.GetPlansByOwner(connectedUserId);
            return dbRecords.Select(_planBuilder.BuildForClient).ToList();
        }
    }
}
