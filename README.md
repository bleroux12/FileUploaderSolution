# File Import and FTP Queue System - ASP.NET Core MVC

## Overview

This project is a **.NET Core MVC application** designed to manage import files and associated documents. It allows users to:

- Create new import file records via manual creation or through an excel template.
- Upload multiple documents against each import file.
- Queue import files for transmission to an FTP server.

The actual uploading of the files to FTP is handled by a seperate windows service.
