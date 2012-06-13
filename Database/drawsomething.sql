-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- 主机: localhost
-- 生成日期: 2012 年 06 月 13 日 22:37
-- 服务器版本: 5.5.20
-- PHP 版本: 5.3.10

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- 数据库: `drawsomething`
--

-- --------------------------------------------------------

--
-- 表的结构 `ds_queun`
--

DROP TABLE IF EXISTS `ds_queun`;
CREATE TABLE IF NOT EXISTS `ds_queun` (
  `qid` int(11) NOT NULL AUTO_INCREMENT,
  `sender_uid` int(11) NOT NULL,
  `receiver_uid` int(11) NOT NULL,
  `drawthing` varchar(255) NOT NULL,
  `xmlbody` longtext NOT NULL,
  `isdone` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`qid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- 表的结构 `ds_user`
--

DROP TABLE IF EXISTS `ds_user`;
CREATE TABLE IF NOT EXISTS `ds_user` (
  `uid` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `score` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- 转存表中的数据 `ds_user`
--

INSERT INTO `ds_user` (`uid`, `username`, `password`, `score`) VALUES
(1, 'admin', 'admin', 100),
(2, 'zhaoyulee', 'zhaoyulee', 60);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
