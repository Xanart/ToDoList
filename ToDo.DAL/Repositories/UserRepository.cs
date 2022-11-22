﻿using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.DAL.Entities;
using ToDo.DAL.Interfaces;

namespace ToDo.DAL.Repositories
{
    public class UsersRepository : GenericRepository<User>, IUserRepository
    {
        public UsersRepository(ToDoListContext context) : base(context)
        {
        }

        public override async Task<ICollection<User>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public override async Task<User> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public override async Task Create(User user)
        {
            await dbSet.AddAsync(user);
        }

        public override async Task Delete(int userId)
        {
            User user = await dbSet.FindAsync(userId);
            dbSet.Remove(user);
        }

        //public List<Objective> GetObjectives(int boardId)
        //{

        //    var objectives = _context.Objectives.Where(o => o.BoardId == boardId).OrderBy(c => c.Completed).ToList();
        //    return objectives;
        //}

        //public List<Board> GetBoardsWithObjectives()
        //{
        //    var boards = _context.Boards.Include(o => o.Tasks).ToList();
        //    return boards;
        //}
    }
}
