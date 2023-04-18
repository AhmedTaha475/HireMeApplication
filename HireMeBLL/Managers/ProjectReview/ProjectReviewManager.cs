﻿using HireMeBLL.Dtos.ProjectReview;
using HireMeDAL.Repos.ProjectsReview;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public class ProjectReviewManager : IProjectReviewManager
    {
        private readonly IProjectsReviewRepo reviewRepo;

        public ProjectReviewManager(IProjectsReviewRepo reviewRepo)
        {
            this.reviewRepo = reviewRepo;
        }

        public List<UserPojectReviewReadDto> GetReviewsByFreeLancerId(string fL_id)
        {
            var R = reviewRepo.GetAllByFreeLancerId(fL_id);
            return R.Select(r =>
                new UserPojectReviewReadDto()
                {
                    ClientReview = r.ClientReview,
                    ClientStars = r.ClientStars ,
                    FreeLancerReview =r.FreelancerReview,
                    FreeLancerStars = r.FreelancerStars,
                    Client = new UserChildReadDto()
                    {
                        Id = r.ClientId,
                        FName = r.Client.FirstName,
                        LName = r.Client.LastName,
                        img = r.Client.Image
                    },
                    FreeLancer = new UserChildReadDto()
                    {
                        Id = r.FreeLancerId,
                        FName = r.Freelancer.FirstName,
                        LName = r.Freelancer.LastName,
                        img = r.Freelancer.Image
                    },
                    Project = new Dtos.ProjectComment.ProjectChildReadDto()
                    {
                        P_Id = r.ProjectId,
                        Title = r.Project.ProjectTitle
                    }
                }).ToList();
        }
        public List<UserPojectReviewReadDto> GetReviewsByClientId(string Client_id)
        {
            var R = reviewRepo.GetAllByClientId(Client_id);
            return R.Select(r =>
                 new UserPojectReviewReadDto()
                 {
                     ClientReview = r.ClientReview,
                     ClientStars = r.ClientStars ,
                     FreeLancerReview = r.FreelancerReview,
                     FreeLancerStars = r.FreelancerStars ,
                     Client = new UserChildReadDto()
                     {
                         Id = r.ClientId,
                         FName = r.Client.FirstName,
                         LName = r.Client.LastName,
                         img = r.Client.Image
                     },
                     FreeLancer = new UserChildReadDto()
                     {
                         Id = r.FreeLancerId,
                         FName = r.Freelancer.FirstName,
                         LName = r.Freelancer.LastName,
                         img = r.Freelancer.Image
                     },
                     Project = new Dtos.ProjectComment.ProjectChildReadDto()
                     {
                         P_Id = r.ProjectId,
                         Title = r.Project.ProjectTitle
                     }
                 }).ToList();
        }

        public PojectReviewReadDto GetReviewByProjectId(int p_Id)
        {
            var Review = reviewRepo.GetByProjectId(p_Id);
            return new PojectReviewReadDto()
            {
                PR_Id = Review.PR_Id,
                ClientReview = Review.ClientReview,
                ClientStars = Review.ClientStars,
                FreelancerReview = Review.FreelancerReview,
                FreelancerStars = Review.FreelancerStars,
                Client = new UserChildReadDto()
                {
                    Id = Review.ClientId,
                    FName = Review.Client.FirstName,
                    LName = Review.Client.LastName,
                    img = Review.Client.Image
                },
                Freelancer = new UserChildReadDto()
                {
                    Id = Review.FreeLancerId,
                    FName = Review.Freelancer.FirstName,
                    LName = Review.Freelancer.LastName,
                    img = Review.Freelancer.Image
                }
            };
        }

        public bool AddClientReview(CreateClientProjectReviewDto createClientReviewdto)
        {
            if (reviewRepo.Add(new HireMeDAL.ProjectReview()
            {
                ClientId = createClientReviewdto.Client_Id,
                ClientReview = createClientReviewdto.Client_Review,
                ClientStars = createClientReviewdto.Client_Stars,
                ProjectId = createClientReviewdto.P_Id
            })) return true;
            return false;
        }

        public bool AddFreeLancerReview(CreateFreeLancerProjectReviewDto createFreeLancerReviewdto, int PR_Id)
        {
            var review = reviewRepo.GetByProjectId(createFreeLancerReviewdto.Project_Id);
            if (reviewRepo.Update(new HireMeDAL.ProjectReview()
            {
                FreeLancerId = createFreeLancerReviewdto.FreeLancer_Id,
                FreelancerReview = createFreeLancerReviewdto.Freelncer_Review,
                FreelancerStars = createFreeLancerReviewdto.Freelancer_Stars,               
            }, PR_Id)) 
            return true;
            return false;
        }
    }
}