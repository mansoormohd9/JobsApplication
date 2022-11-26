const PROXY_CONFIG = [
  {
    context: [
      "/api/jobApplications",
      "/UploadedFiles",
    ],
    target: "https://localhost:7102",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
