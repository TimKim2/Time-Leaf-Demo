public class LostItemReaction : DelayedReaction
{
    public Item item;
	public int itemNumber;

    private Inventory inventory;


    protected override void SpecificInit()
    {
        inventory = FindObjectOfType<Inventory> ();
    }


    protected override void ImmediateReaction()
    {
        //inventory.RemoveItem (ItemNumber);
        Inventory.instance.DeleteItem(itemNumber);

        // AllItemSaveDatas.asset ���Ͽ� ���� Ư�� �ε����� ������ false�� ��ȯ
        AllItemSaveDatas.Instance.itemSaveDatas[itemNumber].satisfied = false;
    }
}
