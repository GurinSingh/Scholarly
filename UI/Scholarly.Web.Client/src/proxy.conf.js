const PROXY_CONFIG = [
  {
    context: [
      '/article',
      '/user',
      '/user/save',
      '/user/education',
      '/user/workexperience',
      '/content/save'
    ],
    target: "http://localhost:5207",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
