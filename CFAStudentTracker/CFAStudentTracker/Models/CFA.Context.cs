﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CFAStudentTracker.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CFAEntities : DbContext
    {
        public CFAEntities()
            : base("name=CFAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FileType> FileType { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Hour> Hour { get; set; }
        public virtual DbSet<HourBase> HourBase { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Processing> Processing { get; set; }
        public virtual DbSet<Queue> Queue { get; set; }
        public virtual DbSet<QueueOrder> QueueOrder { get; set; }
        public virtual DbSet<QueuePriority> QueuePriority { get; set; }
        public virtual DbSet<Record> Record { get; set; }
        public virtual DbSet<StudentFile> StudentFile { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<GlobalSettings> GlobalSettings { get; set; }
    
        [DbFunction("CFAEntities", "UserFilingCabinet")]
        public virtual IQueryable<UserFilingCabinet_Result> UserFilingCabinet(string insUsername)
        {
            var insUsernameParameter = insUsername != null ?
                new ObjectParameter("InsUsername", insUsername) :
                new ObjectParameter("InsUsername", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<UserFilingCabinet_Result>("[CFAEntities].[UserFilingCabinet](@InsUsername)", insUsernameParameter);
        }
    
        [DbFunction("CFAEntities", "UserQueue")]
        public virtual IQueryable<UserQueue_Result> UserQueue(string insUsername, Nullable<short> insQueueID)
        {
            var insUsernameParameter = insUsername != null ?
                new ObjectParameter("InsUsername", insUsername) :
                new ObjectParameter("InsUsername", typeof(string));
    
            var insQueueIDParameter = insQueueID.HasValue ?
                new ObjectParameter("InsQueueID", insQueueID) :
                new ObjectParameter("InsQueueID", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<UserQueue_Result>("[CFAEntities].[UserQueue](@InsUsername, @InsQueueID)", insUsernameParameter, insQueueIDParameter);
        }
    
        public virtual int sp_CompleteProcessing(Nullable<long> insProcID, Nullable<short> curQueueID)
        {
            var insProcIDParameter = insProcID.HasValue ?
                new ObjectParameter("InsProcID", insProcID) :
                new ObjectParameter("InsProcID", typeof(long));
    
            var curQueueIDParameter = curQueueID.HasValue ?
                new ObjectParameter("CurQueueID", curQueueID) :
                new ObjectParameter("CurQueueID", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CompleteProcessing", insProcIDParameter, curQueueIDParameter);
        }
    
        public virtual int sp_GetNextFile(string insUsername, Nullable<short> queueID)
        {
            var insUsernameParameter = insUsername != null ?
                new ObjectParameter("InsUsername", insUsername) :
                new ObjectParameter("InsUsername", typeof(string));
    
            var queueIDParameter = queueID.HasValue ?
                new ObjectParameter("QueueID", queueID) :
                new ObjectParameter("QueueID", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_GetNextFile", insUsernameParameter, queueIDParameter);
        }
    
        public virtual int sp_InsertUser(string insUsername)
        {
            var insUsernameParameter = insUsername != null ?
                new ObjectParameter("InsUsername", insUsername) :
                new ObjectParameter("InsUsername", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertUser", insUsernameParameter);
        }
    
        [DbFunction("CFAEntities", "GetQueues")]
        public virtual IQueryable<GetQueues_Result> GetQueues(string insUsername)
        {
            var insUsernameParameter = insUsername != null ?
                new ObjectParameter("InsUsername", insUsername) :
                new ObjectParameter("InsUsername", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GetQueues_Result>("[CFAEntities].[GetQueues](@InsUsername)", insUsernameParameter);
        }
    
        [DbFunction("CFAEntities", "FilesInQueue")]
        public virtual IQueryable<FilesInQueue_Result> FilesInQueue(Nullable<short> insQueue)
        {
            var insQueueParameter = insQueue.HasValue ?
                new ObjectParameter("InsQueue", insQueue) :
                new ObjectParameter("InsQueue", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FilesInQueue_Result>("[CFAEntities].[FilesInQueue](@InsQueue)", insQueueParameter);
        }
    
        [DbFunction("CFAEntities", "UsersInQueue")]
        public virtual IQueryable<string> UsersInQueue(Nullable<short> insQueue)
        {
            var insQueueParameter = insQueue.HasValue ?
                new ObjectParameter("InsQueue", insQueue) :
                new ObjectParameter("InsQueue", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<string>("[CFAEntities].[UsersInQueue](@InsQueue)", insQueueParameter);
        }
    }
}
