﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Archive.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ArchiveEntities : DbContext
    {
        public ArchiveEntities()
            : base("name=ArchiveEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CodeRange> CodeRanges { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ContentType> ContentTypes { get; set; }
        public virtual DbSet<Editor> Editors { get; set; }
        public virtual DbSet<FileType> FileTypes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<PadidAvar> PadidAvars { get; set; }
        public virtual DbSet<PermissionType> PermissionTypes { get; set; }
        public virtual DbSet<PublishState> PublishStates { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<View> Views { get; set; }
        public virtual DbSet<WorkFlowState> WorkFlowStates { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentResourceRelation> DocumentResourceRelations { get; set; }
        public virtual DbSet<DocumentSubjectRelation> DocumentSubjectRelations { get; set; }
        public virtual DbSet<PermissionLevel> PermissionLevels { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
    }
}