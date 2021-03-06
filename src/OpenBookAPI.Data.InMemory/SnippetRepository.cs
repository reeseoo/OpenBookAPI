﻿using OpenBookAPI.Data.Interfaces;
using OpenBookAPI.Logic.Interfaces;
using OpenBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBookAPI.Data.InMemory
{
    
    public class SnippetRepository:ISnippetRepository
    {
        private List<Snippet> _dataContext;

        public SnippetRepository()
        {
            Guid storyId = new Guid("8e733419-c6a3-4b59-8d5a-8784c1b61724");
            Guid submission1 = new Guid("3f6945fe-83e4-478b-8dd4-9ffbc66a9f35");
            Guid submission2 = new Guid("cbe0ee1b-04fc-4502-92e6-652537f58965"); 
            Guid submission3 =new Guid("233ae5e6-6333-4874-bb64-93585f05d26d");

            _dataContext = new List<Snippet>
            {
                new Snippet{
                    Id = new Guid("ba0088dd-587d-4e16-a338-2446abfe459b"),
                    Content = "Once upon a time there was a little boy named Reese,",
                    Author = "John",
                    NewParagraph = false,
                    StoryId = storyId,
                    SubmissionDate = new DateTime(2015,10,11),
                    Score = 10,
                    Flags = 1,
                    Status = SnippetStatus.Chosen,
                    SubmissionPeriodId = submission1
                },new Snippet{
                    Id = new Guid("5d6932f8-5886-4723-8eb8-c243c40da684"),
                    Content = "He was always late for his lunch appointments.",
                    Author = "John",
                    NewParagraph = false,
                    StoryId = storyId,
                    SubmissionDate = new DateTime(2015,10,11,6,0,0),
                    Score = 5,
                    Status = SnippetStatus.Chosen,
                    SubmissionPeriodId = submission1
                },new Snippet{
                    Id = new Guid("1227e500-071c-48ef-b92d-690a99d0ec21"),
                    Content = "BLAH BLAH BLAH.",
                    Author = "John",
                    NewParagraph = true,
                    StoryId = storyId,
                    SubmissionDate = new DateTime(2015,10,11,12,0,0),
                    Score = 0,
                    Status = SnippetStatus.Submitted,
                    SubmissionPeriodId = submission1
                },
                new Snippet{
                    Id = new Guid("1227e500-071c-48ef-b92d-690a99d0ec21"),
                    Content = "Once upon a time there was a little boy named Reese,",
                    Author = "John",
                    NewParagraph = false,
                    StoryId = storyId,
                    SubmissionDate = new DateTime(2015,10,11),
                    Score = 10,
                    Status = SnippetStatus.Submitted,
                    SubmissionPeriodId = submission2
                },new Snippet{
                    Id = new Guid("1227e500-071c-48ef-b92d-690a99d0ec21"),
                    Content = "He was always late for his lunch appointments.",
                    Author = "John",
                    NewParagraph = false,
                    StoryId =storyId,
                    SubmissionDate = new DateTime(2015,10,11,6,0,0),
                    Score = 5,
                    Status = SnippetStatus.Chosen,
                    SubmissionPeriodId = submission2,
                },new Snippet{
                    Id = new Guid("1227e500-071c-48ef-b92d-690a99d0ec21"),
                    Content = "BLAH BLAH BLAH.",
                    Author = "John",
                    NewParagraph = true,
                    StoryId = storyId,
                    SubmissionDate = new DateTime(2015,10,11,12,0,0),
                    Score = 0,
                    Status = SnippetStatus.Submitted,
                    SubmissionPeriodId = submission3
                }
            };
        }

        public async Task<Snippet> GetById(Guid snippetId)
        {
            return _dataContext.FirstOrDefault(s => s.Id == snippetId);
        }

        public async Task<IEnumerable<Snippet>> GetAll()
        {
            return _dataContext.OrderByDescending(s=>s.Score);
        }
        public async Task<IEnumerable<Snippet>> GetByStory(Guid storyId)
        {
            return _dataContext.Where(a=>a.StoryId == storyId).OrderByDescending(s=>s.Score);
        }

        public async Task<IEnumerable<Snippet>> GetBySubmissionPeriodId(Guid submissionPeriodId)
        {
            return _dataContext.Where(sp => sp.SubmissionPeriodId == submissionPeriodId).OrderByDescending(s=>s.Score);
        }

        public async Task<Snippet> Create(Snippet snippet)
        {
            snippet.Id = Guid.NewGuid();
            _dataContext.Add(snippet);
            return snippet;
        }

        public async Task<Snippet> Update(Snippet snippet)
        {
            var old = await GetById(snippet.Id);
            if (old == null)
                return null;
            _dataContext.Remove(old);
            _dataContext.Add(snippet);
            return snippet;
        }

        public async Task<bool> Delete(Guid id)
        {
            var old = await GetById(id);
            if (old == null)
                return false;
            return _dataContext.Remove(old);
        }
    }
}
