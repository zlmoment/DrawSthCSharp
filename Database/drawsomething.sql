-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- 主机: localhost
-- 生成日期: 2012 年 06 月 13 日 18:11
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
  `xmlbody` text NOT NULL,
  `isdone` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`qid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- 转存表中的数据 `ds_queun`
--

INSERT INTO `ds_queun` (`qid`, `sender_uid`, `receiver_uid`, `drawthing`, `xmlbody`, `isdone`) VALUES
(2, 1, 2, 'water', '<Trace>\r\n  <Section penColor="-16777216" penWidth="1">\r\n    <Point time="0">\r\n      <X>72</X>\r\n      <Y>63</Y>\r\n    </Point>\r\n  </Section>\r\n  <Section penColor="-16777216" penWidth="1">\r\n    <Point time="30">\r\n      <X>72</X>\r\n      <Y>63</Y>\r\n    </Point>\r\n    <Point time="60">\r\n      <X>75</X>\r\n      <Y>64</Y>\r\n    </Point>\r\n    <Point time="90">\r\n      <X>81</X>\r\n      <Y>75</Y>\r\n    </Point>\r\n    <Point time="120">\r\n      <X>90</X>\r\n      <Y>102</Y>\r\n    </Point>\r\n    <Point time="150">\r\n      <X>104</X>\r\n      <Y>140</Y>\r\n    </Point>\r\n    <Point time="180">\r\n      <X>122</X>\r\n      <Y>165</Y>\r\n    </Point>\r\n    <Point time="210">\r\n      <X>134</X>\r\n      <Y>170</Y>\r\n    </Point>\r\n    <Point time="240">\r\n      <X>163</X>\r\n      <Y>169</Y>\r\n    </Point>\r\n    <Point time="270">\r\n      <X>198</X>\r\n      <Y>158</Y>\r\n    </Point>\r\n    <Point time="300">\r\n      <X>236</X>\r\n      <Y>134</Y>\r\n    </Point>\r\n    <Point time="330">\r\n      <X>265</X>\r\n      <Y>111</Y>\r\n    </Point>\r\n    <Point time="360">\r\n      <X>287</X>\r\n      <Y>93</Y>\r\n    </Point>\r\n    <Point time="390">\r\n      <X>311</X>\r\n      <Y>83</Y>\r\n    </Point>\r\n    <Point time="420">\r\n      <X>323</X>\r\n      <Y>82</Y>\r\n    </Point>\r\n    <Point time="450">\r\n      <X>328</X>\r\n      <Y>88</Y>\r\n    </Point>\r\n    <Point time="480">\r\n      <X>338</X>\r\n      <Y>105</Y>\r\n    </Point>\r\n    <Point time="510">\r\n      <X>344</X>\r\n      <Y>115</Y>\r\n    </Point>\r\n    <Point time="540">\r\n      <X>359</X>\r\n      <Y>143</Y>\r\n    </Point>\r\n    <Point time="570">\r\n      <X>370</X>\r\n      <Y>162</Y>\r\n    </Point>\r\n    <Point time="600">\r\n      <X>379</X>\r\n      <Y>173</Y>\r\n    </Point>\r\n    <Point time="630">\r\n      <X>385</X>\r\n      <Y>175</Y>\r\n    </Point>\r\n    <Point time="660">\r\n      <X>392</X>\r\n      <Y>173</Y>\r\n    </Point>\r\n    <Point time="690">\r\n      <X>416</X>\r\n      <Y>155</Y>\r\n    </Point>\r\n    <Point time="720">\r\n      <X>434</X>\r\n      <Y>130</Y>\r\n    </Point>\r\n    <Point time="750">\r\n      <X>446</X>\r\n      <Y>114</Y>\r\n    </Point>\r\n    <Point time="780">\r\n      <X>455</X>\r\n      <Y>106</Y>\r\n    </Point>\r\n    <Point time="810">\r\n      <X>468</X>\r\n      <Y>100</Y>\r\n    </Point>\r\n    <Point time="840">\r\n      <X>482</X>\r\n      <Y>100</Y>\r\n    </Point>\r\n    <Point time="870">\r\n      <X>486</X>\r\n      <Y>103</Y>\r\n    </Point>\r\n    <Point time="900">\r\n      <X>495</X>\r\n      <Y>111</Y>\r\n    </Point>\r\n    <Point time="930">\r\n      <X>511</X>\r\n      <Y>126</Y>\r\n    </Point>\r\n    <Point time="960">\r\n      <X>534</X>\r\n      <Y>148</Y>\r\n    </Point>\r\n    <Point time="990">\r\n      <X>555</X>\r\n      <Y>166</Y>\r\n    </Point>\r\n    <Point time="1020">\r\n      <X>566</X>\r\n      <Y>168</Y>\r\n    </Point>\r\n    <Point time="1050">\r\n      <X>579</X>\r\n      <Y>167</Y>\r\n    </Point>\r\n    <Point time="1080">\r\n      <X>589</X>\r\n      <Y>157</Y>\r\n    </Point>\r\n    <Point time="1110">\r\n      <X>596</X>\r\n      <Y>145</Y>\r\n    </Point>\r\n    <Point time="1140">\r\n      <X>598</X>\r\n      <Y>136</Y>\r\n    </Point>\r\n    <Point time="1170">\r\n      <X>598</X>\r\n      <Y>128</Y>\r\n    </Point>\r\n    <Point time="1200">\r\n      <X>598</X>\r\n      <Y>124</Y>\r\n    </Point>\r\n  </Section>\r\n  <Section penColor="-16777216" penWidth="1">\r\n    <Point time="1740">\r\n      <X>49</X>\r\n      <Y>217</Y>\r\n    </Point>\r\n    <Point time="1770">\r\n      <X>49</X>\r\n      <Y>217</Y>\r\n    </Point>\r\n    <Point time="1800">\r\n      <X>51</X>\r\n      <Y>218</Y>\r\n    </Point>\r\n    <Point time="1830">\r\n      <X>62</X>\r\n      <Y>236</Y>\r\n    </Point>\r\n    <Point time="1860">\r\n      <X>87</X>\r\n      <Y>268</Y>\r\n    </Point>\r\n    <Point time="1890">\r\n      <X>123</X>\r\n      <Y>294</Y>\r\n    </Point>\r\n    <Point time="1920">\r\n      <X>154</X>\r\n      <Y>293</Y>\r\n    </Point>\r\n    <Point time="1950">\r\n      <X>190</X>\r\n      <Y>275</Y>\r\n    </Point>\r\n    <Point time="1980">\r\n      <X>232</X>\r\n      <Y>242</Y>\r\n    </Point>\r\n    <Point time="2010">\r\n      <X>261</X>\r\n      <Y>220</Y>\r\n    </Point>\r\n    <Point time="2040">\r\n      <X>280</X>\r\n      <Y>213</Y>\r\n    </Point>\r\n    <Point time="2070">\r\n      <X>287</X>\r\n      <Y>217</Y>\r\n    </Point>\r\n    <Point time="2100">\r\n      <X>293</X>\r\n      <Y>225</Y>\r\n    </Point>\r\n    <Point time="2130">\r\n      <X>310</X>\r\n      <Y>248</Y>\r\n    </Point>\r\n    <Point time="2160">\r\n      <X>327</X>\r\n      <Y>274</Y>\r\n    </Point>\r\n    <Point time="2190">\r\n      <X>354</X>\r\n      <Y>295</Y>\r\n    </Point>\r\n    <Point time="2220">\r\n      <X>367</X>\r\n      <Y>298</Y>\r\n    </Point>\r\n    <Point time="2250">\r\n      <X>385</X>\r\n      <Y>292</Y>\r\n    </Point>\r\n    <Point time="2280">\r\n      <X>417</X>\r\n      <Y>276</Y>\r\n    </Point>\r\n    <Point time="2310">\r\n      <X>453</X>\r\n      <Y>257</Y>\r\n    </Point>\r\n    <Point time="2340">\r\n      <X>474</X>\r\n      <Y>247</Y>\r\n    </Point>\r\n    <Point time="2370">\r\n      <X>482</X>\r\n      <Y>249</Y>\r\n    </Point>\r\n    <Point time="2400">\r\n      <X>488</X>\r\n      <Y>253</Y>\r\n    </Point>\r\n    <Point time="2430">\r\n      <X>501</X>\r\n      <Y>263</Y>\r\n    </Point>\r\n    <Point time="2460">\r\n      <X>518</X>\r\n      <Y>279</Y>\r\n    </Point>\r\n    <Point time="2490">\r\n      <X>535</X>\r\n      <Y>295</Y>\r\n    </Point>\r\n    <Point time="2520">\r\n      <X>552</X>\r\n      <Y>304</Y>\r\n    </Point>\r\n    <Point time="2550">\r\n      <X>568</X>\r\n      <Y>306</Y>\r\n    </Point>\r\n    <Point time="2580">\r\n      <X>598</X>\r\n      <Y>296</Y>\r\n    </Point>\r\n    <Point time="2610">\r\n      <X>633</X>\r\n      <Y>274</Y>\r\n    </Point>\r\n    <Point time="2640">\r\n      <X>660</X>\r\n      <Y>247</Y>\r\n    </Point>\r\n    <Point time="2670">\r\n      <X>674</X>\r\n      <Y>224</Y>\r\n    </Point>\r\n    <Point time="2700">\r\n      <X>674</X>\r\n      <Y>218</Y>\r\n    </Point>\r\n  </Section>\r\n</Trace>', 0);

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
(2, 'zhaoyulee', 'zhaoyulee', 0);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
