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
    
    //得到排行榜 
    public function gettoplist()
    {
    	$User = M ( "User" );
    	$result = $User->order("score DESC")->limit('5')->select();
    	//var_dump($result);
    	foreach ($result as $result_single) {
    		$result_back .= ($result_single["username"].",".$result_single["score"].",");
		}
		$result_back = substr($result_back,0,strlen($result_back)-1);
		echo $result_back;
    }
}