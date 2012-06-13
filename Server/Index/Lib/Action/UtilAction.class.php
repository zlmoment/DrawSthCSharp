<?php
class UtilAction extends Action {
	
    public function getuidfromusername(){
    	
    }
    
    //得到某用户的积分
    public function getscorebyuid(){
    	 $uid = $_GET['uid'];
    	 $User = M ( "User" );
    	 $result = $User->find($uid);
    	 if ($result) {
    	 	echo $result['score'];
    	 } else {
    	 	echo "0";
    	 }
    }
}