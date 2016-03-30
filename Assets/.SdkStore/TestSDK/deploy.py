#!/usr/bin/env python
# -*- coding: UTF-8 -*-

from fabric.state import env
from fabric.api import run
from fabric.api import put
from fabric.api import local
from fabric.api import cd
from fabric.contrib.files import exists


def set_hosts():
    env.user = 'deploy'
    env.hosts = ['103.192.178.32:36957']
    env.passwords = {'deploy@103.192.178.32:36957':'learntolive'}

def pack():
    #tar -cvf /home/www/images.tar /home/www/images
    local("tar -zcvf pkg.tar.gz ./*")

def deploy():
    
    run("echo clean files on server")
    ## rm /home/www/xclouder.com
    run("rm -rf /home/www/xclouder.com/*")

    #upload pkg
    run("echo upload pkg")
    run("mkdir tmp")
    put('pkg.tar.gz', 'tmp/pkg.tar.gz')

    #unpack pkg
    run("echo unpack pkg")
    run("mkdir /home/www/xclouder.com/tmp")
    run ("tar -zxvf tmp/pkg.tar.gz -C /home/www/xclouder.com")

    #clean
    run("rm -rf ./*")
