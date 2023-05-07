﻿using LearningApp.Models.Entities;

namespace LearningApp.Contracts.Services;

public interface ILecturesService
{
    public Task<IEnumerable<Lecture>> GetLecturesByChapterAsync(int chapterId);
}

