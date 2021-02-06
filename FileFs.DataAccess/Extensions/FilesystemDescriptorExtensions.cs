﻿using FileFs.DataAccess.Entities;

namespace FileFs.DataAccess.Extensions
{
    public static class FilesystemDescriptorExtensions
    {
        public static FilesystemDescriptor WithFileDataLength(this in FilesystemDescriptor descriptor, int filesDataLength)
        {
            return new FilesystemDescriptor(
                filesDataLength,
                descriptor.FileDescriptorsCount,
                descriptor.FileDescriptorLength,
                descriptor.Version);
        }

        public static FilesystemDescriptor WithFileDescriptorsCount(this in FilesystemDescriptor descriptor, int fileDescriptorsCount)
        {
            return new FilesystemDescriptor(
                descriptor.FilesDataLength,
                fileDescriptorsCount,
                descriptor.FileDescriptorLength,
                descriptor.Version);
        }

        public static FilesystemDescriptor WithFileDescriptorLength(this in FilesystemDescriptor descriptor, int fileDescriptorLength)
        {
            return new FilesystemDescriptor(
                descriptor.FilesDataLength,
                descriptor.FileDescriptorsCount,
                fileDescriptorLength,
                descriptor.Version);
        }

        public static FilesystemDescriptor WithVersion(this in FilesystemDescriptor descriptor, int version)
        {
            return new FilesystemDescriptor(
                descriptor.FilesDataLength,
                descriptor.FileDescriptorsCount,
                descriptor.FileDescriptorLength,
                version);
        }
    }
}