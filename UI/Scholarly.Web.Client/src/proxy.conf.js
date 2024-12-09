const PROXY_CONFIG = [
  {
    context: [
      '/article/get',
      '/user',
      '/user/save',
      '/user/education',
      '/user/workexperience',
      '/article/save',
    ],
    target: "http://localhost:5207",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
