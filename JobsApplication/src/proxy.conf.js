const PROXY_CONFIG = [
  {
    context: [
      "/jobApplications",
    ],
    target: "https://localhost:7102",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
