###参考文献
https://github.com/cuber/ngx_http_google_filter_module/blob/master/README.zh-CN.md  

###配置文件目录
/opt/nginx-1.7.8/conf

###配置文件
nginx.conf

###http配置方式
####修改nginx.conf  
        resolver 8.8.8.8;  ##添加  
        location / {  
                google on;  ##添加  
                #root   html;			##注释  
                #index  index.html index.htm;  ##注释  
				
        }  
		
###https配置方式 
生成证书和密锁
http://luckywnj.iteye.com/blog/1707048

####生成普通私钥
openssl genrsa -out cert.key 1024

####通过生成的私钥去生成证书
openssl req -new -x509 -key cert.key -out cert.pem -days 1095

####修改nginx.conf
server {
	listen       443 ssl;
	server_name  localhost;

	ssl on;
	ssl_certificate      cert.pem;
	ssl_certificate_key  cert.key;

#    ssl_session_cache    shared:SSL:1m;
#    ssl_session_timeout  5m;

#    ssl_ciphers  HIGH:!aNULL:!MD5;
#    ssl_prefer_server_ciphers  on;
	resolver 8.8.8.8;
	location / {
			google on;
	}
}


