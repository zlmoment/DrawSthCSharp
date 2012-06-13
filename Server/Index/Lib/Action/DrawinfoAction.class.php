<?php
class DrawinfoAction extends Action {
	
	//添加一个新的图画
    public function addnewdraw(){
    	$sender_uid = "";
    	$receiver_uid = "";
    	$drawthing = "";
    	$xmlbody = "";
    	
        $sender_uid = $_POST['sender_uid'];
        $receiver_uid = $_POST['receiver_uid'];
        $drawthing = $_POST['drawthing'];
        $xmlbody = $_POST['xmlbody'];
        
        $Queun = M ("Queun");
        $Queun->sender_uid = $sender_uid;
        $Queun->receiver_uid = $receiver_uid;
        $Queun->drawthing = $drawthing;
        $Queun->xmlbody = $xmlbody;
        $result = $Queun->add();
        if ($result) {
        	echo "true";
        } else {
        	echo "false";
        }
    }
}