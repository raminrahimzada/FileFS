﻿using System.Collections.Generic;
using FileFS.Api.Abstractions;
using FileFs.DataAccess;
using FileFs.DataAccess.Repositories;
using FileFs.DataAccess.Serializers;
using FileFS.Managers;
using FileFS.Managers.Models;
using Microsoft.Extensions.Logging;

namespace FileFS.Api
{
    public class FileFsClient : IFileFsClient
    {
        private readonly FileFsManager _manager;

        public FileFsClient(string fileFsPath, ILoggerFactory loggerFactory)
        {
            var connection = new StorageConnection(fileFsPath, loggerFactory.CreateLogger<StorageConnection>());

            var filesystemSerializer = new FilesystemDescriptorSerializer();
            var filesystemRepository = new FilesystemDescriptorRepository(connection, filesystemSerializer);

            var fileDescriptorSerializer = new FileDescriptorSerializer(filesystemRepository);
            var fileDescriptorRepository = new FileDescriptorRepository(connection, filesystemRepository, fileDescriptorSerializer);

            var fileDataRepository = new FileDataRepository(connection);

            var optimizer = new StorageOptimizer(fileDescriptorRepository, fileDataRepository, loggerFactory.CreateLogger<StorageOptimizer>());
            var allocator = new FileAllocator(connection, filesystemRepository, fileDescriptorRepository, optimizer, loggerFactory.CreateLogger<FileAllocator>());

            var externalFileManager = new ExternalFileManager(loggerFactory.CreateLogger<ExternalFileManager>());

            _manager = new FileFsManager(allocator, fileDataRepository, filesystemRepository, fileDescriptorRepository, optimizer, externalFileManager, loggerFactory.CreateLogger<FileFsManager>());
        }

        public void Create(string fileName, byte[] content)
        {
            _manager.Create(fileName, content);
        }

        public void Update(string fileName, byte[] newContent)
        {
            _manager.Update(fileName, newContent);
        }

        public void Delete(string fileName)
        {
            _manager.Delete(fileName);
        }

        public void Import(string externalPath, string fileName)
        {
            _manager.Import(externalPath, fileName);
        }

        public void Export(string fileName, string externalPath)
        {
            _manager.Export(fileName, externalPath);
        }

        public byte[] Read(string fileName)
        {
            return _manager.Read(fileName);
        }

        public bool Exists(string fileName)
        {
            return _manager.Exists(fileName);
        }

        public void Rename(string oldName, string newName)
        {
            _manager.Rename(oldName, newName);
        }

        public IReadOnlyCollection<EntryInfo> List()
        {
            return _manager.List();
        }

        public void ForceOptimize()
        {
            _manager.ForceOptimize();
        }
    }
}