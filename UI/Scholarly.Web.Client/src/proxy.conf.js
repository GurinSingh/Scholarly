const PROXY_CONFIG = [
  {
    context: [
      '/article',
      '/user',
      '/user/save',
      '/user/education',
      '/user/workexperience'
    ],
    target: "http://localhost:5207",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
