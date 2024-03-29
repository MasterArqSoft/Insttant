﻿using CodeFirst.Core.Interfaces.Repositories;
using CodeFirst.Domain.Entities;
using CodeFirst.Infrastructure.Repositories.RespositoryAsync;
using CodeFirst.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CodeFirstContext _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(CodeFirstContext context)
        {
            _context = context;
        }
        public IGenericRepository<Field> FieldRepositoryAsync => new FieldRepositoryAsync(_context);

        public IGenericRepository<StepToFlow> StepToFlowRepositoryAsync => new StepToFlowRepositoryAsync(_context);

        public IGenericRepository<Flow> FlowRepositoryAsync => new FlowRepositoryAsync(_context);

        public IGenericRepository<Step> StepRepositoryAsync => new StepRepositoryAsync(_context);
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync().ConfigureAwait(false);
        }

        public async Task CommitAsync()
        {
            try
            {
                await BeginTransactionAsync();
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                Dispose();
            }
        }

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task RollbackAsync()
        {
            _transaction.Rollback();
            _transaction.Dispose();
            return Task.CompletedTask;
        }
    }
}
