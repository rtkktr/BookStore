//using BookStore.Domain.Models;
//using BookStore.Infrastructure.Contracts;
//using BookStore.Infrastructure.Services.Statuses;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BookStore.Infrastructure.Services
//{
//    public class OrderHeaderRepository : IOrderHeaderRepository<Guid?, bool, RepositoryStatus>
//    {
//        private readonly ApplicationDbContext _context;

//        public OrderHeaderRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<RepositoryStatus> DeleteAsync(OrderHeader? entity)
//        {
//            try
//            {
//                if (entity == null)
//                    return RepositoryStatus.NullEntity;
//                entity.IsDeleted = true;
//                _context.OrderHeader.Update(entity);
//                await _context.SaveChangesAsync();
//                return RepositoryStatus.Success;

//            }
//            catch (Exception)
//            {
//                return RepositoryStatus.DatabaseError;
//            }
//        }

//        public async Task<RepositoryStatus> DeleteByIdAsync(Guid? id)
//        {
//            try
//            {
//                var orderHeader = await _context.OrderHeader.FirstOrDefaultAsync(o => o.Id == id);
//                if (orderHeader == null) return RepositoryStatus.NullEntity;
//                orderHeader.IsDeleted = true;
//                _context.OrderHeader.Update(orderHeader);
//                await _context.SaveChangesAsync();
//                return RepositoryStatus.Success;
//            }
//            catch (Exception)
//            {
//                return RepositoryStatus.DatabaseError;
//            }
//        }

//        public async Task<RepositoryStatus> InsertAsync(OrderHeader? entity)
//        {
//            try
//            {
//                if (entity == null)
//                    return RepositoryStatus.NullEntity;
//                await _context.OrderHeader.AddAsync(entity);
//                await _context.SaveChangesAsync();
//                return RepositoryStatus.Success;
//            }
//            catch (Exception)
//            {
//                return RepositoryStatus.DatabaseError;
//            }
//        }

//        public (bool, RepositoryStatus) IsExist(Guid? id)
//        {
//            try
//            {
//                bool isExist = (_context.OrderHeader?.Any(o => o.Id == id)).GetValueOrDefault();
//                return (isExist, RepositoryStatus.Success);
//            }
//            catch (Exception)
//            {
//                return (false, RepositoryStatus.NotExist);
//            }
//        }

//        public async Task<(IEnumerable<OrderHeader?>?, RepositoryStatus)> SelectAllAsync()
//        {
//            try
//            {
//                var orderHeaders = await _context.OrderHeader.ToListAsync();
//                if (orderHeaders == null || orderHeaders.Count == 0)
//                    return (null, RepositoryStatus.TableIsEmpty);
//                return (orderHeaders, RepositoryStatus.Success);
//            }
//            catch (Exception)
//            {
//                return (null, RepositoryStatus.DatabaseError);
//            }
//        }

//        public async Task<(OrderHeader?, RepositoryStatus)> SelectByIdAsync(Guid? id)
//        {
//            try
//            {
//                var orderHeader = await _context.OrderHeader.FirstOrDefaultAsync(o => o.Id == id);
//                if (orderHeader == null)
//                    return (null, RepositoryStatus.NotExist);
//                return (orderHeader, RepositoryStatus.Success);
//            }
//            catch (Exception)
//            {
//                return (null, RepositoryStatus.DatabaseError);
//            }
//        }

//        public async Task<RepositoryStatus> UpdateAsync(OrderHeader? entity)
//        {
//            try
//            {
//                if (entity == null)
//                    return RepositoryStatus.NullEntity;
//                _context.OrderHeader.Update(entity);
//                await _context.SaveChangesAsync();
//                return RepositoryStatus.Success;

//            }
//            catch (Exception)
//            {
//                return RepositoryStatus.DatabaseError;
//            }
//        }
//    }
//}
