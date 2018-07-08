public class PickedUpItemReaction : DelayedReaction
{
  //  public Item item;

	public int itemNumber;
  //  private Inventory inventory;


    protected override void SpecificInit()
    {
     //   inventory = FindObjectOfType<Inventory>();
    }


    protected override void ImmediateReaction()
    {
        //		inventory.AddItem(itemNumber);
        Inventory.instance.AddItem(itemNumber);

        // AllItemSaveDatas.asset 파일에 가서 특정 인덱스의 아이템 true로 변환
        AllItemSaveDatas.Instance.itemSaveDatas[itemNumber].satisfied = true;
    }
}
