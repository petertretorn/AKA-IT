using FormManager.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FormManager.Data
{
    public static class FormContextExtensions
    {
        public static void SeedData(this FormContext formContext)
        {
            if (formContext.Forms.Any())
            {
                formContext.Forms.RemoveRange(formContext.Forms);
            }
            
            var member_1 = new Member()
            {
                Cpr = "230956-3434",
                FirstName = "Hans",
                LastName = "Pedersen",
                Gender = Gender.Male,
                City = "København",
                Street = "Nørrebrogade 123, 2 tv",
                MemberInfo = new List<MemberInfo>
                {
                    new MemberInfo
                    {
                        Key = "MeetingNote",
                        Value = "Kom igen for sent",
                        DateOfInfo = DateTime.Parse("05/02/2018")
                    }
                }
            };

            var member_2 = new Member()
            {
                Cpr = "110985-2456",
                FirstName = "Grete",
                LastName = "Andersen",
                Gender = Gender.Female,
                City = "Vejle",
                Street = "Nørregade 12",
            };
            
            var caseWorker = new CaseWorker()
            {
                Name = "Sanne Hansen",
                Location = "København",
            };

            var previousEmployer = new Employer()
            {
                Name = "Coloplast",
                Address = "Coloplast Alle 1, Coloplast By",
                CVR = "34343-232-22",
            };

            var forms = new List<Form>
            {
                new UnemployedForm
                {
                    Member = member_1,
                    DateSubmitted = DateTime.Now,
                    PreviousEmployer = previousEmployer,
                    CaseWorker = caseWorker,
                    DateUnemployed = DateTime.Now - TimeSpan.FromDays(33),
                    DateProcessed = DateTime.Now - TimeSpan.FromDays(3),
                    IsProcessed = true
                },
                new UnemployedForm
                {
                    Member = member_2,
                    DateSubmitted = DateTime.Now - TimeSpan.FromDays(100),
                    PreviousEmployer = previousEmployer,
                    CaseWorker = caseWorker,
                    DateUnemployed = DateTime.Now - TimeSpan.FromDays(102),
                    DateProcessed = DateTime.Now - TimeSpan.FromDays(90),
                    IsProcessed = true
                },
                new UnemployedForm
                {
                    Member = member_2,
                    DateSubmitted = DateTime.Now - TimeSpan.FromDays(200),
                    PreviousEmployer = previousEmployer,
                    CaseWorker = caseWorker,
                    DateUnemployed = DateTime.Now - TimeSpan.FromDays(102),
                    DateProcessed = DateTime.Now - TimeSpan.FromDays(90),
                    IsProcessed = true
                },
                new UnemployedForm
                {
                    Member = member_2,
                    DateSubmitted = DateTime.Now - TimeSpan.FromDays(15),
                    PreviousEmployer = previousEmployer,
                    CaseWorker = caseWorker,
                    DateUnemployed = DateTime.Now - TimeSpan.FromDays(102),
                    DateProcessed = DateTime.Now - TimeSpan.FromDays(90),
                    IsProcessed = true
                },
                new UnemployedForm
                {
                    Member = member_2,
                    DateSubmitted = DateTime.Now - TimeSpan.FromDays(11),
                    PreviousEmployer = previousEmployer,
                    CaseWorker = caseWorker,
                    DateUnemployed = DateTime.Now - TimeSpan.FromDays(102),
                    DateProcessed = DateTime.Now - TimeSpan.FromDays(90),
                    IsProcessed = true
                },
                new UnemployedForm
                {
                    Member = member_2,
                    DateSubmitted = DateTime.Now - TimeSpan.FromDays(10),
                    PreviousEmployer = previousEmployer,
                    CaseWorker = caseWorker,
                    DateUnemployed = DateTime.Now - TimeSpan.FromDays(102),
                    DateProcessed = DateTime.Now - TimeSpan.FromDays(90),
                    IsProcessed = true
                }

            };

            formContext.Forms.AddRange(forms);

            formContext.SaveChanges();
        }
    }
}