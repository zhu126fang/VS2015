###安装Dillinger
[Install Dillinger on Debian](http://www.monperrus.net/martin/installing-dillinger-nodejs-debian)  

[installed it on an Ubuntu 14.04.1 LTS server:](http://chrisjrob.com/2014/08/09/dillinger/) 

###Docker说明
[初探Docker](http://www.tuicool.com/articles/BNnyqyU)  

[ubuntu14.04+docker的安装及使用](http://www.jb51.net/article/56049.htm)

###Docker安装Dillinger
Dillinger is very easy to install and deploy in a Docker container.

By default, the Docker will expose port 80, so change this within the Dockerfile if necessary. When ready, simply use the Dockerfile to build the image.  

```sh
cd dillinger  
docker build -t <youruser>/dillinger:latest .
```

This will create the dillinger image and pull in the necessary dependencies. Once done, run the Docker and map the port to whatever you wish on your host. In this example, we simply map port 80 of the host to port 80 of the Docker (or whatever port was exposed in the Dockerfile):  

```sh
docker run -d -p 80:8080 --restart="always" <youruser>/dillinger:latest
```

Verify the deployment by navigating to your server address in your preferred browser.


